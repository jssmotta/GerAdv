'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ContatoCRMGrid from '@/app/GerAdv_TS/ContatoCRM/Crud/Grids/ContatoCRMGrid';
export class ContatoCRMGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ContatoCRMGrid />;
  }
}