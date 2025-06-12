'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import FaseGrid from '@/app/GerAdv_TS/Fase/Crud/Grids/FaseGrid';
export class FaseGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <FaseGrid />;
  }
}