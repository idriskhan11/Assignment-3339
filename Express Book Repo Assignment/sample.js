const app=require("express")();
const server= require("mssql/msnodesqlv8")
const parser=require('body-parser')
app.use (parser.urlencoded({"extended":true}))
app.use(parser.json())





const config={
    server:'.\\SQLEXPRESS',
    database:'master',
    //instance:'SQLEXPRESS'
    driver:'msnodesqlv8',
    options:{
        trustedConnection:true,
        TrustServerCertificate:true
    }
}

const pool=new server.ConnectionPool(config)

//form post
app.get("/Form",(req,res)=>res.sendFile(__dirname+"/BookAdding.html"));
app.get("/TableOfRecords",(req,res)=>res.sendFile(__dirname+"/Table.html"));

app.post("/formPost",(req,res)=>{
    const body=req.body;
    const query=`INSERT INTO book VALUES(${body.id},'${body.name}','${body.author}',${body.price})`;
    pool.connect().then(()=>{
        pool.request().query(query,(err,result)=>{
            if(err)
            console.log(err);
            else
            res.send("Book inserted sucessfully")
            
        })
    }).catch((err)=>{
        console.error(err);
        
    })
})

app.get('/',(req,res)=>{
    
//connect to the database
pool.connect().then(()=>{
    pool.request().query("SELECT * FROM book",(err,results)=>{
        if(err)
        console.error(err)
        else
        res.send(results.recordset);
    })
}).catch((err)=>{
    if(err)
    console.log(err)
})
})
//app.listen(1254,()=> console.log("server at1251"))


//search by id
app.get('/:id',(req,res)=>{
    const id=parseInt(req.params.id);
    pool.connect().then(()=>{
        pool.request().query(`select * from book where bookId = ${id}`,(err, results)=>{
        if(err)
        console.error(err);
        else
        res.send(results.recordset)
    })
}).catch((err)=>{
    if(err)
    console.log(err);
})
})



//app.listen(1257,()=> console.log("server at 1257"))

app.delete('/:id',(req,res)=>{
    const id=parseInt(req.params.id);
    pool.connect().then(()=>{
        pool.request().query(`delete from book where bookId = ${id}`,(err, results)=>{
        if(err)
        console.error(err);
        else
        res.send("delete successfully")
    })
}).catch((err)=>{
    if(err)
    console.log(err);
})
})
//app.listen(1255,()=> console.log("server at 1255"))

app.post('/',(req,res)=>{
    const body=req.body;
    console.log(body);
    const query=`INSERT INTO book VALUES(${body.bookId},'${body.bookName}','${body.bookAuthor}',${body.bookPrice})`;
    pool.connect().then(()=>{
        pool.request().query(query,(err,result)=>{
            if(err)
            console.log(err);
            else
            res.send("New Book inserted successfully")
        })
    }).catch((err)=>{
        console.error(err);
    })
})



app.listen(1250,()=> console.log("server at 1250"))
