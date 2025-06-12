'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { EMPClassRiscosGridAdapter } from '@/app/GerAdv_TS/EMPClassRiscos/Adapter/EMPClassRiscosGridAdapter';
import EMPClassRiscosGridContainer from '@/app/GerAdv_TS/EMPClassRiscos/Components/EMPClassRiscosGridContainer';
const EMPClassRiscosPage: React.FC = () => {
  const EMPClassRiscosGrid = new EMPClassRiscosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='E M P Class Riscos' />
    <EMPClassRiscosGridContainer grid={EMPClassRiscosGrid} />
  </PageLayout>
);
};
export default EMPClassRiscosPage;