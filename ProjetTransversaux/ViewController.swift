//
//  ViewController.swift
//  ProjetTransversaux
//
//  Created by Supinfo on 07/03/16.
//  Copyright © 2016 Ingesup. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }
    
    @IBOutlet weak var UsernameTxt: UITextField!
    @IBOutlet weak var PasswordTxt: UITextField!
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
        
    }
	
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        let sVC: TwoViewController = segue.destinationViewController as! TwoViewController
        
        sVC.Username = UsernameTxt.text!
        sVC.Password = PasswordTxt.text!
    }

}

