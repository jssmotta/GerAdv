'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import GUTTipoGrid from '@/app/GerAdv_TS/GUTTipo/Crud/Grids/GUTTipoGrid';
export class GUTTipoGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <GUTTipoGrid />;
  }
}