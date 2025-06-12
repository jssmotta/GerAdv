'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import AlertasEnviadosGrid from '@/app/GerAdv_TS/AlertasEnviados/Crud/Grids/AlertasEnviadosGrid';
export class AlertasEnviadosGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <AlertasEnviadosGrid />;
  }
}