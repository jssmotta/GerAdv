'use client';
import * as React from 'react';
import { Input, Switch } from '@progress/kendo-react-inputs';
import { Button } from '@progress/kendo-react-buttons';
import { useAppDispatch, useAppSelector } from '../store/hooks';
import { selectSystemContext, selectTextoPesquisado, selectPesquisar, setTextoPesquisado } from '../store/slices/systemContextSlice';
import { useRouter } from 'next/navigation';
import '@/app/styles/MenuAgenda.css';
import { useIsMobile } from '@/app/context/MobileContext';
import {
  AppBar,
  AppBarSection,
  AppBarSpacer,
  Avatar,
} from '@progress/kendo-react-layout';
 
import { MenuButtonOkTop } from './Cruds/MenuButtonOkTop';
import NavButtons from './msi/NavButtons';
import { AgendaBarraSemana } from '../GerAdv/Agenda/AgendaBarraSemana';
import { MenuHamburguer } from './Cruds/MenuHamburguer';

export const Header: React.FC<{
  page?: string;
  onButtonClick?: (event: any) => void;
}> = ({ onButtonClick }) => {
  const dispatch = useAppDispatch();
  const systemContext = useAppSelector(selectSystemContext);
  const textoPesquisado = useAppSelector(selectTextoPesquisado);
  const pesquisar = useAppSelector(selectPesquisar);
  const [searchValue, setSearchValue] = React.useState<string>(
    textoPesquisado ?? ''
  );
  const router = useRouter();
  const isMobile = useIsMobile();

  const handleSearchAgenda = () => {
    dispatch(setTextoPesquisado(searchValue));
    if (typeof window !== 'undefined')
      if (!window.location.href.endsWith('/pesquisa')) {
        router.push('/pesquisa');
      }
  };

  const showSearch = () => {
    return isMobile === false;
  };

  return (
    <>
      <div style={{ height: '50px' }}></div>
      <AppBar
        className="glass-header"
        style={{
          color: '#FFF',
          position: 'fixed',
          top: '-13.5pt',
          left: 0,
          height: '63px',
          width: '100%',
          zIndex: 1000,
        }}
      >
        
        <AppBarSection>
          <NavButtons />
        </AppBarSection>
        {showSearch() && (
          <AppBarSection>
            <div className="pesquisarTop glass-search">
              <form onSubmit={(e) => { e.preventDefault(); handleSearchAgenda(); }}>
              <Input
                type="text"
                aria-label={'Pesquisar'}
                className="k-input input-search"
                value={searchValue}
                onChange={(e) => setSearchValue(e.value)}
                style={{ width: '140px' }}
                title="Procure por paciente, prontuário, nome, data de nascimento..."
                placeholder="Procurar..."                
              />
              <Button type="submit" onClick={handleSearchAgenda} title='Clique para procurar'  aria-label='Buscar' className="button-search">
                &gt;
              </Button>
              </form>
            </div>
          </AppBarSection>
        )}
        <AppBarSection>
          <AgendaBarraSemana />
        </AppBarSection>
        <AppBarSpacer />
        <AppBarSection>
          <h3 className="nameApp">{systemContext?.TenantApp}</h3>     
        </AppBarSection>
        <AppBarSection>
          <MenuHamburguer />
          <MenuButtonOkTop />
        </AppBarSection>
      </AppBar>
    </>
  );
};

Header.displayName = 'Header';
