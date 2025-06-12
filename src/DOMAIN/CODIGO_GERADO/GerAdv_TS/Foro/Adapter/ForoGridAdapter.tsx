'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ForoGrid from '@/app/GerAdv_TS/Foro/Crud/Grids/ForoGrid';
export class ForoGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ForoGrid />;
  }
}