import { Component } from "react";
import OnMainLoad from './onMainLoad.js';
import { BrowserRouter, Route, Switch, NavLink } from 'react-router-dom';
import Entities from "./Entities/exports";

export default class App extends Component {
  componentDidMount(){
    OnMainLoad();
  }

  render() {
    return(
      <div className="someBody once told me the world gonna roll me">
        <NavigationWithContent />
        <BottomContent />
      </div>
    );
  }
}

function NavigationWithContent() {
  return (
  <BrowserRouter>
    <NavigationBar />
    <MainContent />
  </BrowserRouter>
  );
}

function MainContent() {
  return <div className="container-m">
    <div className="home">
      <div className="fadeIn">
        <SwitchNavigationRequest />
      </div>
    </div>
  </div>;
}

function NavigationBar() {
  return(<nav className="navbar navbar-expand-md navbar-light bg-light fixed-top">
  <div className="container container-s">
    <a className="navbar-brand" href="##">Dom.ru TulaHack</a>  
    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span className="navbar-toggler-icon"></span>
    </button>
    <div className="collapse navbar-collapse" id="navbarSupportedContent">
      <ul className="navbar-nav ml-auto navbar-right">
          <li className="nav-item">
            <NavLink className="nav-link js-scroll-trigger" to="/entity1">Описание 1</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link js-scroll-trigger" to="/entity2">Описание 2</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link js-scroll-trigger" to="/entity3">Описание 3</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link js-scroll-trigger" to="/entity4">Описание 4</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link js-scroll-trigger" to="/entity5">Описание 5</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link js-scroll-trigger" to="/entity6">Описание 6</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link js-scroll-trigger" to="/entity7">Описание 7</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link js-scroll-trigger" to="/entity8">Описание 8</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link js-scroll-trigger" to="/entity9">Описание 9</NavLink>
          </li>
      </ul>
    </div>
  </div>
</nav>);
}

function SwitchNavigationRequest(){
  return (
  <Switch>
    <Route path='/entity1' component={Entities.Entity1}/>
    <Route path='/entity2' component={Entities.Entity2}/>
    <Route path='/entity3' component={Entities.Entity3}/>
    <Route path='/entity4' component={Entities.Entity4}/>
    <Route path='/entity5' component={Entities.Entity5}/>
    <Route path='/entity6' component={Entities.Entity6}/>
    <Route path='/entity7' component={Entities.Entity7}/>
    <Route path='/entity8' component={Entities.Entity8}/>
    <Route path='/entity9' component={Entities.Entity9}/>
  </Switch>
  );
}
  
function BottomContent() {
  return <div className="footer-sm">
    <div className="row">
      <div className="col-md-12 text-center">
        <h6>&copy; 2021 WNW Command</h6>
      </div>
    </div>
  </div>;
}