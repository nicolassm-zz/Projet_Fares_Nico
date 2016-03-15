//
//  TimeliveVie.swift
//  ProjetTransversaux
//
//  Created by Supinfo on 15/03/16.
//  Copyright © 2016 Ingesup. All rights reserved.
//

import Foundation
// Swift
import TwitterKit

class TweetTableViewDemoViewController: UITableView, TWTRTweetViewDelegate {
    let tweetTableReuseIdentifier = "TweetCell"
    
    var dataSource:TWTRUserTimelineDataSource
    // Hold all the loaded Tweets
    var tweets: [TWTRTweet] = [] {
        didSet {
            self.reloadData()
        }
    }
    let tweetIDs = ["20", // @jack's first Tweet
        "510908133917487104"] // our favorite bike Tweet
    
    func viewDidLoad() {
        let Session = Twitter.sharedInstance().sessionStore.session()
        let client = TWTRAPIClient(userID: Session!.userID)
        client.loadUserWithID(Session!.userID) { (user, error) -> Void in
            
            dataSource = TWTRUserTimelineDataSource(screenName: (user!.screenName)!, APIClient: client)
        }

    }
    

}