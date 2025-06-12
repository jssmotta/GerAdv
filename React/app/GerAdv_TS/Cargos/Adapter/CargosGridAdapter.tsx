'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import CargosGrid from '@/app/GerAdv_TS/Cargos/Crud/Grids/CargosGrid';
export class CargosGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <CargosGrid />;
  }
}