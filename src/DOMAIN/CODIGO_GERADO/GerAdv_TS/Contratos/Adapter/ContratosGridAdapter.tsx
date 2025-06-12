'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ContratosGrid from '@/app/GerAdv_TS/Contratos/Crud/Grids/ContratosGrid';
export class ContratosGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ContratosGrid />;
  }
}