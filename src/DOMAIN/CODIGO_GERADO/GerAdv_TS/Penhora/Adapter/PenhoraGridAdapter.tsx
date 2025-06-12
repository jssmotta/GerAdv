'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import PenhoraGrid from '@/app/GerAdv_TS/Penhora/Crud/Grids/PenhoraGrid';
export class PenhoraGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <PenhoraGrid />;
  }
}