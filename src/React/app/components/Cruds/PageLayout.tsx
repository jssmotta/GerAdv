import Layout from '@/app/GerAdv/Menu/DrawerLayout';

export interface PageLayoutProps {
  children: React.ReactNode;
}

export const PageLayout: React.FC<PageLayoutProps> = ({ children }) => (
  <Layout>
    <div className="pageContainer">{children}</div>
  </Layout>
);
