'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { AlertasEnviadosGridAdapter } from '@/app/GerAdv_TS/AlertasEnviados/Adapter/AlertasEnviadosGridAdapter';
import AlertasEnviadosGridContainer from '@/app/GerAdv_TS/AlertasEnviados/Components/AlertasEnviadosGridContainer';
const AlertasEnviadosPage: React.FC = () => {
  const AlertasEnviadosGrid = new AlertasEnviadosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Alertas Enviados' />
    <AlertasEnviadosGridContainer grid={AlertasEnviadosGrid} />
  </PageLayout>
);
};
export default AlertasEnviadosPage;