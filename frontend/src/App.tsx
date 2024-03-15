import React from 'react';
import logo from './logo.svg';
import './App.css';
import Header from './Header';
import BowlerList from './Bowler/BowlerList';

function App() {
  return (
    <div className="App">
      <Header title="Bowler List" />
      <BowlerList />
    </div>
  );
}

export default App;
