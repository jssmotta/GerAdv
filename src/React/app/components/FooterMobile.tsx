import React, { useState } from 'react';
import { useRouter } from 'next/navigation';
import {
  homeIcon,
  plusIcon,
  zoomInIcon,
  calendarIcon,
  logoutIcon,
} from '@progress/kendo-svg-icons';
import { useAppDispatch, useAppSelector } from '../store/hooks';
import { selectTextoPesquisado, setTextoPesquisado, setSystemContext } from '../store/slices/systemContextSlice';
import { Button } from '@progress/kendo-react-buttons';
import { Dialog } from '@progress/kendo-react-dialogs'; 
import {
  BottomNavigationSelectEvent,
  BottomNavigation,
} from '@progress/kendo-react-layout';
import ClientesWindowId from '../GerAdv_TS/Clientes/Crud/Grids/ClientesWindowId';
import InputNomePaciente from '@/app/GerAdv/Inputs/InputNomePaciente';
import { useIsMobile } from '../context/MobileContext';

const MobileFooter = () => {
  const isMobile = useIsMobile();
  const dispatch = useAppDispatch();
  const textoPesquisado = useAppSelector(selectTextoPesquisado);
  const router = useRouter();
  const [showSearchDialog, setShowSearchDialog] = useState(false);
  const [showClientes, setShowClientes] = useState(false);

  const handleHomeClick = () => {
    router.push('/dashboard');
    router.refresh();
  };

  const handleNewClienteClick = () => {
    setShowClientes(true);
  };

  const handleSearchClick = () => {
    setShowSearchDialog(true);
  };

  const handleScheduleClick = () => {
    router.push(`/pages/agenda`);
    router.refresh();
  };

  const handleLogoutClick = () => {
    dispatch(setSystemContext(null));
    router.push('/auth');
  }; 
  
  const setSelectedTab = (event: BottomNavigationSelectEvent) => {
    switch (event.itemTarget.value) {
      case 'home':
        handleHomeClick();
        break;
      case 'novo':
        handleNewClienteClick();
        break;
      case 'search':
        handleSearchClick();
        break;
      case 'calendar':
        handleScheduleClick();
        break;
      case 'more':
        handleLogoutClick();
        break;
      default:
        break;
    }
  };

  const closeSearchDialog = () => {
    setShowSearchDialog(false);
  };

  const [searchValue, setSearchValue] = useState<string>(textoPesquisado ?? '');

  const closeClientes = () => {
    setShowClientes(false);
  };

  const pressSearch = () => {    
      setShowSearchDialog(false);      
      dispatch(setTextoPesquisado(searchValue));                  
      router.push('/pesquisa');
    };

    // Don't render if not mobile
    if (!isMobile) {
      return null;
    }

    return (
      <>
        {showClientes && (
          <ClientesWindowId
            id={0}
            isOpen={showClientes}
            onClose={closeClientes}
            onSuccess={closeClientes}
            onError={closeClientes}
          />
        )}

        {showSearchDialog && (
          <>
            <style>
              {`
            .k-window {
              position: fixed !important;
              width: calc(100vw - 40px) !important; 
              max-width: calc(100vw - 40px) !important;
              height: auto !important;
              min-height: 200px !important;
              left: 50% !important;
              top: 50% !important;
              transform: translate(-50%, -50%) !important;
              margin: 0 !important;
              box-sizing: border-box !important;
            }
            .k-window-content {
              padding: 20px !important;
              box-sizing: border-box !important; 
              background-color: #fff !important;
            }
            .input-search {
              width: 100% !important;
              margin-bottom: 20px !important;
              box-sizing: border-box !important;
            }
            .input-search .k-input {
              width: 100% !important;
              box-sizing: border-box !important;
            }
            .buttonOk {
              width: 100% !important;
              height: 44px !important;
              box-sizing: border-box !important;
              font-size: 16px !important;
            }
          `}
            </style>
            <Dialog title="Pesquisar" onClose={closeSearchDialog}>
              <form onSubmit={e => { e.preventDefault(); pressSearch(); }}>
                <InputNomePaciente
                  type="text"
                  id="search-input"
                  label="Pesquisa"
                  name="searchValue"
                  value={searchValue}
                  onChange={(e: any) => setSearchValue(e.value)}
                  placeholder="Digite sua pesquisa..."
                  className='input-search'
                />
                <Button
                  className="buttonOk"
                  themeColor="primary"
                  onClick={() => pressSearch()}
                  type='submit'
                >
                  Pesquisar
                </Button>
              </form>
            </Dialog>
          </>
        )}
        <BottomNavigation          
          onSelect={setSelectedTab}
          className='footer-container'
          items={[
            {
              text: 'Home',
              icon: 'home',
              value: 'home',
              svgIcon: homeIcon,
            },
            {
              text: 'Novo',
              icon: 'plus',
              value: 'novo',
              svgIcon: plusIcon,
            },
            {
              text: 'Busca',
              icon: 'search',
              value: 'search',
              svgIcon: zoomInIcon,
            },
            {
              text: 'Consultas',
              icon: 'calendar',
              value: 'calendar',
              svgIcon: calendarIcon,
            },
            {
              text: 'Sair',
              icon: 'more-horizontal',
              value: 'more',
              svgIcon: logoutIcon,
            },
          ]}
        />
      </>
    );
  };

  export default MobileFooter;
