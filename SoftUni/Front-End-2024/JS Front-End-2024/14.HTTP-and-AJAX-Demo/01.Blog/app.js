function attachEvents() {
    const postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';

    const loadPostsButton = document.getElementById('btnLoadPosts');
    const postViewButton = document.getElementById('btnViewPost');
    const selectPostElement = document.getElementById('posts');
    const postBodyElement = document.getElementById('post-body');
    const commentListElement = document.getElementById('post-comments');
    const postTitleElement = document.getElementById('post-title');

    loadPostsButton.addEventListener('click', () => {
        selectPostElement.innerHTML = '';
        
        fetch(postsUrl)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Failed to load posts');
                }
                return response.json();
            })
            .then(posts => {
                Object.values(posts)
                    .forEach(post => {
                        const optionElement = document.createElement('option');
                        optionElement.value = post.id;
                        optionElement.textContent = post.title;

                        selectPostElement.appendChild(optionElement);
                    });
            })
            .catch(error => {
                console.error('Error loading posts:', error);
            });
    });

    postViewButton.addEventListener('click', async () => {
        const selectedPostId = selectPostElement.value;

        if (!selectedPostId) {
            alert('Please select a post');
            return;
        }

        try {
            const postResponse = await fetch(`${postsUrl}/${selectedPostId}`);
            if (!postResponse.ok) {
                throw new Error('Failed to load post');
            }
            const selectedPost = await postResponse.json();

            postBodyElement.textContent = selectedPost.body;
            postTitleElement.textContent = selectedPost.title;

            const commentsResponse = await fetch(commentsUrl);
            if (!commentsResponse.ok) {
                throw new Error('Failed to load comments');
            }
            const comments = await commentsResponse.json();
            const commentsFragment = document.createDocumentFragment();

            Object.values(comments)
                .filter(comment => comment.postId === selectedPostId)
                .forEach(comment => {
                    const liElement = document.createElement('li');
                    liElement.id = comment.id;
                    liElement.textContent = comment.text;

                    commentsFragment.appendChild(liElement);
                });
            
            commentListElement.innerHTML = '';
            commentListElement.appendChild(commentsFragment);
        } catch (error) {
            console.error('Error loading post and comments:', error);
        }
    });
}

attachEvents();
