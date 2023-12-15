import Catalog from '../../features/cataog/Catalog';
import {
  Container,
  CssBaseline,
  ThemeProvider,
  createTheme,
} from '@mui/material';
import Header from './Header';
import { useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';
import ProductDetails from '../../features/cataog/ProductDetails';
import AboutPage from '../../features/about/AboutPage';
import ContactPage from '../../features/contact/ContactPage';

export default function App() {
  const [darkMode, setDarkMode] = useState(true);
  const paletteType = darkMode ? 'dark' : 'light';

  const theme = createTheme({
    palette: {
      mode: paletteType,
    },
  });

  function handleThemeChange() {
    setDarkMode(!darkMode);
  }

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Header darkMode={darkMode} handleThemeChange={handleThemeChange} />
      <Container>
        <Routes>
          <Route path="/" Component={HomePage} />
          <Route path="/catalog" Component={Catalog} />
          <Route path="/catalog/:id" Component={ProductDetails} />
          <Route path="/about" Component={AboutPage} />
          <Route path="/contact" Component={ContactPage} />
        </Routes>
      </Container>
    </ThemeProvider>
  );
}
