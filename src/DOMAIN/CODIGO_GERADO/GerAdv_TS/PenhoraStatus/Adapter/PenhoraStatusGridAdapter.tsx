'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import PenhoraStatusGrid from '@/app/GerAdv_TS/PenhoraStatus/Crud/Grids/PenhoraStatusGrid';
export class PenhoraStatusGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <PenhoraStatusGrid />;
  }
}