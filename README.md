# Flappy
#🔥Vấn đề dùng list để làm observer =)):
- Chuyện là: Game có score, scorePopUp(hiển thị khi game over), hightScore(Hiển thị khi game over)
	- Observer có listener thằng score rồi, hightscore cũng vậy nhưng =)):
	- mỗi khi làm với những thằng không liên quan thì lại phải tạo addObserver, RemoveObserver và Notify 
	- 💡Dùng list không giòn
	- 👉 dùng **Dictionary** tối ưu
#🔥Logic dotween làm animation
- Khi chuyển scene về lại scene cũ thì tween không hoạt động trở lại
	- 👉 thêm SetUpdate(true) để nó không bị destroy khi chuyển scene
	- Tại sao bị thế: do cơ chế loadscene của unity