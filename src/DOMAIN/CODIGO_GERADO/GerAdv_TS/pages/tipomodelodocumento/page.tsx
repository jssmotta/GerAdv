'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { TipoModeloDocumentoGridAdapter } from '@/app/GerAdv_TS/TipoModeloDocumento/Adapter/TipoModeloDocumentoGridAdapter';
import TipoModeloDocumentoGridContainer from '@/app/GerAdv_TS/TipoModeloDocumento/Components/TipoModeloDocumentoGridContainer';
const TipoModeloDocumentoPage: React.FC = () => {
  const TipoModeloDocumentoGrid = new TipoModeloDocumentoGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Tipo Modelo Documento' />
    <TipoModeloDocumentoGridContainer grid={TipoModeloDocumentoGrid} />
  </PageLayout>
);
};
export default TipoModeloDocumentoPage;