import { AppBar, Toolbar, Typography } from '@mui/material';
import ThemeSwitch from './ThemeSwitch';

interface Props {
  darkMode: boolean;
  handleThemeChange: () => void;
}
export default function Header({ darkMode, handleThemeChange }: Props) {
  return (
    <AppBar position="static" sx={{ mb: 4 }}>
      <Toolbar>
        <Typography variant="h5">BIMSAGE Store</Typography>
        {/* <Switch checked={darkMode} onChange={handleThemeChange}></Switch> */}
        <ThemeSwitch
          checked={darkMode}
          onChange={handleThemeChange}
          sx={{ m: 1 }}
        />
      </Toolbar>
    </AppBar>
  );
}
