'use client';
import { useMenu } from '@/app/context/MenuContext';
import { Button } from '@progress/kendo-react-buttons';
import { menuIcon } from '@progress/kendo-svg-icons';

export const MenuHamburguer: React.FC = () => {
  const { toggleMenu } = useMenu();

  return (
    <Button
      svgIcon={menuIcon}
      onClick={toggleMenu}
      title="Toggle Menu" 
      aria-label="Toggle Menu"
      className="menu-toggle-button-top"
    />
  );
};
