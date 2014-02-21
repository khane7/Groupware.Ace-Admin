using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CCms
{
	public int idx { get; set; }
	public int board_no { get; set; }
	public int pid { get; set; }
	public int depth { get; set; }
	public string user_id { get; set; }
	public string user_name { get; set; }
	public string subject { get; set; }
	public string body { get; set; }
	public DateTime regdate { get; set; }
	public DateTime moddate { get; set; }
	public string regip { get; set; }
	public int commentcnt { get; set; }
	public int viewcnt { get; set; }
	public string content { get; set; }
	public string isdeleted { get; set; }

	public string sort_field { get; set; }
	public string sort_type { get; set; }
}