'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ProCDAGrid from '@/app/GerAdv_TS/ProCDA/Crud/Grids/ProCDAGrid';
export class ProCDAGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ProCDAGrid />;
  }
}