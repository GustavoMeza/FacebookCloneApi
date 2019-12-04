pablo = { _id: ObjectId("507f191e810c19729de86000"),    firstName: "Pablo",     lastName: "Arellano",   email: "paar@xyz.com",       password: "123" };
luis =  { _id: ObjectId("507f191e810c19729de86001"),    firstName: "Luis",      lastName: "Zermeño",    email: "luze@ijk.edu.mx",    password: "456" };
fati =  { _id: ObjectId("507f191e810c19729de86002"),    firstName: "Fátima",    lastName: "Arámbula",   email: "faar@abc.com.mx",    password: "789" };

friendships = [
    { _id: ObjectId("507f191e810c19729de86010"),    userAId: pablo._id, userBId: luis._id   },
    { _id: ObjectId("507f191e810c19729de86011"),    userAId: pablo._id, userBId: fati._id,  },
    { _id: ObjectId("507f191e810c19729de86012"),    userAId: luis._id,  userBId: fati._id,  },
];

posts = [
    { _id: ObjectId("507f191e810c19729de86020"),    userId: pablo._id,  content: "Post 1",  createTime: new Date(2019, 10, 25, 1)   },
    { _id: ObjectId("507f191e810c19729de86021"),    userId: pablo._id,  content: "Post 2",  createTime: new Date(2019, 10, 25, 2)   },
    { _id: ObjectId("507f191e810c19729de86022"),    userId: luis._id,   content: "Post 3",  createTime: new Date(2019, 10, 25, 3)   },
    { _id: ObjectId("507f191e810c19729de86023"),    userId: luis._id,   content: "Post 4",  createTime: new Date(2019, 10, 25, 4)   },
    { _id: ObjectId("507f191e810c19729de86024"),    userId: fati._id,   content: "Post 5",  createTime: new Date(2019, 10, 25, 5)   },
    { _id: ObjectId("507f191e810c19729de86025"),    userId: fati._id,   content: "Post 6",  createTime: new Date(2019, 10, 25, 6)   },
];

comments = [
    { _id: ObjectId("507f191e810c19729de86030"),    userId: pablo._id,   postId: posts[0]._id,  content: "Comment 1",   createTime: new Date(2019, 10, 25, 4)   }, 
    { _id: ObjectId("507f191e810c19729de86031"),    userId: luis._id,    postId: posts[0]._id,  content: "Comment 2",   createTime: new Date(2019, 10, 25, 2)   }, 
    { _id: ObjectId("507f191e810c19729de86032"),    userId: luis._id,    postId: posts[4]._id,  content: "Comment 3",   createTime: new Date(2019, 10, 25, 6)   }, 
    { _id: ObjectId("507f191e810c19729de86033"),    userId: fati._id,    postId: posts[0]._id,  content: "Comment 4",   createTime: new Date(2019, 10, 25, 3)   }, 
];

likes = [
    { _id: ObjectId("507f191e810c19729de86040"),    userId: pablo._id,  postId: posts[2]._id    },
    { _id: ObjectId("507f191e810c19729de86041"),    userId: pablo._id,  postId: posts[5]._id    },
    { _id: ObjectId("507f191e810c19729de86042"),    userId: luis._id,   postId: posts[0]._id    },
    { _id: ObjectId("507f191e810c19729de86043"),    userId: luis._id,   postId: posts[4]._id    },
    { _id: ObjectId("507f191e810c19729de86044"),    userId: fati._id,   postId: posts[0]._id    },
    { _id: ObjectId("507f191e810c19729de86045"),    userId: fati._id,   postId: posts[1]._id    },
];

dbname = 'facebookDB';
db = db.getSiblingDB(dbname);
db.dropDatabase();

db.users.insertMany([pablo, luis, fati]);
db.friendships.insertMany(friendships);
db.posts.insertMany(posts);
db.comments.insertMany(comments);
db.likes.insertMany(likes);
