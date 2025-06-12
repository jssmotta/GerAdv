'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import AndCompGrid from '@/app/GerAdv_TS/AndComp/Crud/Grids/AndCompGrid';
export class AndCompGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <AndCompGrid />;
  }
}