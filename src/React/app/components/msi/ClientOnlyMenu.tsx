'use client';

import * as React from 'react';
import { Menu } from '@progress/kendo-react-layout';

interface ClientOnlyMenuProps {
  items: any[];
}

const ClientOnlyMenu: React.FC<ClientOnlyMenuProps> = (props) => {
  const [isMounted, setIsMounted] = React.useState(false);

  React.useEffect(() => {
    setIsMounted(true);
  }, []);

  if (!isMounted) {
    return null;
  }

  return <Menu items={props.items} />;
};

export default ClientOnlyMenu;
