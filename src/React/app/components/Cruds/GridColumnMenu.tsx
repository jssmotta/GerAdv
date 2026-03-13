// GridColumnMenu.tsx
import React from 'react';
import {
  GridColumnMenuColumnsChooser,
  GridColumnMenuFilter,
  GridColumnMenuSort,
  GridColumnState
} from '@progress/kendo-react-grid';

interface GridColumnMenuProps {
  columnsState: GridColumnState[];
  onColumnsStateChange: (e: any) => void;
}

export const GridColumnMenu = ({ 
  columnsState, 
  onColumnsStateChange 
}: GridColumnMenuProps) => {
  
  const chooserColumnMenu = (props: any) => {
    return (
      <div>
        <GridColumnMenuSort {...props} />
        <GridColumnMenuFilter {...props} />
        <GridColumnMenuColumnsChooser
          {...props}
          columnsState={columnsState}
          onColumnsStateChange={(e: any) => {
            let columnsStateArray;
  
            if (Array.isArray(e)) {
              columnsStateArray = e;
            } else if (e && e.columnsState && Array.isArray(e.columnsState)) {
              columnsStateArray = e.columnsState;
            } else {
              console.warn('Invalid chooser event:', e);
              return;
            }
  
            onColumnsStateChange(columnsStateArray);
          }}
        />
      </div>
    );
  };

  return chooserColumnMenu;
};