'use client';
import { 
    GridColumn,
    GridColumnState,
} from '@progress/kendo-react-grid';
import { Children, isValidElement } from 'react';
 
export const extractColumnsFromChildren = (children: React.ReactNode): GridColumnState[] => {
  const columnsState: GridColumnState[] = [];
  
  const processChildren = (childrenToProcess: React.ReactNode) => {
    Children.forEach(childrenToProcess, (child) => {
      if (isValidElement(child)) {        
        if (child.type === GridColumn || (child.type as any)?.displayName === 'GridColumn') {      
          const props = child.props as any;
          if (props.field) {
            columnsState.push({
              id: props.field,
              field: props.field,          
              hidden: Boolean(props.hidden !== undefined ? props.hidden : false),
              width: props.width,
              title: props.title
            });
          }
        }        
        const childProps = child.props as any;
        if (childProps && childProps.children) {
          processChildren(childProps.children);
        }
      }
    });
  };
  
  if (Array.isArray(children)) {
    processChildren(children);
  } else {
    processChildren(children);
  }
  
  return columnsState;
};