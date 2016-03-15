//
//  TimelineController.swift
//  ProjetTransversaux
//
//  Created by Supinfo on 15/03/16.
//  Copyright © 2016 Ingesup. All rights reserved.
//

import Foundation
import UIKit
import TwitterKit


class SearchTimelineViewController: TWTRTimelineViewController{
    override func viewDidLoad() {
        super.viewDidLoad()
        
        let client = TWTRAPIClient()
        self.dataSource = TWTRUserTimelineDataSource(screenName: "fabric", APIClient: client)
    }
}