export interface IPageTitle {
  title: string;
  helpButton?: React.ReactNode;
}


export const PageTitle: React.FC<IPageTitle> = ({ title, helpButton }) => (
  <h1
    className='title-page-cad'
    style={{ position: 'relative', display: 'flex', alignItems: 'center', paddingRight: '16px', minHeight: '40px' }}
  >
    <span style={{ position: 'absolute', left: '50%', transform: 'translateX(-50%)', whiteSpace: 'nowrap' }}>{title}</span>

    {helpButton && (
      <span
        className='help-button'
        style={{ position: 'absolute', right: '8px', top: '50%', transform: 'translateY(-50%)', display: 'inline-flex', alignItems: 'center' }}
      >
        {helpButton}
      </span>
    )}
  </h1>
);
