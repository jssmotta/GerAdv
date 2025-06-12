'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { OponentesRepLegalGridAdapter } from '@/app/GerAdv_TS/OponentesRepLegal/Adapter/OponentesRepLegalGridAdapter';
import OponentesRepLegalGridContainer from '@/app/GerAdv_TS/OponentesRepLegal/Components/OponentesRepLegalGridContainer';
const OponentesRepLegalPage: React.FC = () => {
  const OponentesRepLegalGrid = new OponentesRepLegalGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Oponentes Rep Legal' />
    <OponentesRepLegalGridContainer grid={OponentesRepLegalGrid} />
  </PageLayout>
);
};
export default OponentesRepLegalPage;