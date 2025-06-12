'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { TipoOrigemSucumbenciaGridAdapter } from '@/app/GerAdv_TS/TipoOrigemSucumbencia/Adapter/TipoOrigemSucumbenciaGridAdapter';
import TipoOrigemSucumbenciaGridContainer from '@/app/GerAdv_TS/TipoOrigemSucumbencia/Components/TipoOrigemSucumbenciaGridContainer';
const TipoOrigemSucumbenciaPage: React.FC = () => {
  const TipoOrigemSucumbenciaGrid = new TipoOrigemSucumbenciaGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Tipo Origem Sucumbencia' />
    <TipoOrigemSucumbenciaGridContainer grid={TipoOrigemSucumbenciaGrid} />
  </PageLayout>
);
};
export default TipoOrigemSucumbenciaPage;