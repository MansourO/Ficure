import React from 'react';
import { DataGrid } from '@material-ui/data-grid';
import axios from 'axios';

const columns = [
  { field: 'id', headerName: 'Id', width: 130 },
  { field: 'userId', headerName: 'UserId', width: 130 },
  { field: 'name', headerName: 'Name', width: 130 },
  { field: 'amount', headerName: 'Amount', width: 130 }
];

export default class TransactionList extends React.Component {
  state = {
    transactions: []
  }

  componentDidMount(){
    axios.get(`https://localhost:44377/api/UserTransaction/GetTransactions`, 
    {
      params: {
        UserId: '79e814c5-31e8-4a91-8c97-8c57cfccbc33'
      }
    })
    .then(res => {
      const transactions = res.data
      this.setState({ 
        transactions: transactions 
      });

      console.log(this.state.transactions);
    })
  }

  render() {
    return (
      <ul>
        {<h1>Transactions</h1>}
         <div style={{ height: 400, width: '100%' }}>
           <DataGrid columns={columns} rows={this.state.transactions} />
        </div> 
      </ul>
    )
  }
}