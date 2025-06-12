'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ProResumosGrid from '@/app/GerAdv_TS/ProResumos/Crud/Grids/ProResumosGrid';
export class ProResumosGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ProResumosGrid />;
  }
}