//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ContaCorrenteEmpty } from '../../../Models/ContaCorrente';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IContaCorrente } from '../../Interfaces/interface.ContaCorrente';
import { ContaCorrenteService } from '../../Services/ContaCorrente.service';
import { ContaCorrenteApi } from '../../Apis/ApiContaCorrente';
import { ContaCorrenteGridMobileComponent } from '../GridsMobile/ContaCorrente';
import { ContaCorrenteGridDesktopComponent } from '../GridsDesktop/ContaCorrente';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterContaCorrente } from '../../Filters/ContaCorrente';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ContaCorrenteWindow from './ContaCorrenteWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useContaCorrenteList } from '../../Hooks/hookContaCorrente';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ContaCorrenteGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const contacorrenteService = useMemo(() => {
    return new ContaCorrenteService(
    new ContaCorrenteApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: contacorrente, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useContaCorrenteList(contacorrenteService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedContaCorrente, setSelectedContaCorrente] = useState<IContaCorrente>(ContaCorrenteEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterContaCorrente | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterContaCorrente | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterContaCorrente);
};
// Handlers para o grid
const handleRowClick = (contacorrente: IContaCorrente) => {
  setSelectedContaCorrente(contacorrente);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedContaCorrente(ContaCorrenteEmpty());
  setShowInc(true);
};
const handleClose = () => {
  setShowInc(false);
};
const handleSuccess = () => {
  setShowInc(false);
  // O hook já escuta as notificações e recarrega automaticamente
};
const handleError = () => {
  setShowInc(false);
};
// Handlers para exclusão
const onDeleteClick = (e: any) => {
  const contacorrente = e.dataItem;
  setDeleteId(contacorrente.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await contacorrenteService.deleteContaCorrente(deleteId);
      // O hook já escuta as notificações e recarrega automaticamente
    } catch (error) {
    console.error('Erro ao excluir:', error);
    setErrorMessage('Erro ao excluir o registro. Verifique se ele não está vinculado a outros registros.');
  } finally {
  setDeleteId(null);
  setIsModalOpen(false);
}
}
};
const cancelDelete = () => {
  setDeleteId(null);
  setIsModalOpen(false);
};
// Combinar erro do hook com erro local
const displayError = error || errorMessage;
useEffect(() => {
  const unsubscribe = subscribeToNotifications('*', (entity) => {
    if (entity.action == NotifySystemActions.ERROR) {
      return;
    }
    reloadFilter();
  });
  return () => {
    unsubscribe();
  };
}, []);
return (
<>
<AppGridToolbar onAdd={handleAdd} />
{loading && (
  <LoadingSpinner />
  )}
  {isMobile ? (
    <ContaCorrenteGridMobileComponent
    data={contacorrente}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ContaCorrenteGridDesktopComponent
    data={contacorrente}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ContaCorrenteWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedContaCorrente={selectedContaCorrente}
    />

    <ConfirmationModal
    isOpen={isModalOpen}
    onConfirm={confirmDelete}
    onCancel={cancelDelete}
    message={`Deseja realmente excluir o registro?`}
    />
    <ErrorMessage
    mensagem={displayError}
    setErrorMessage={setErrorMessage}
    />
  </>
);
};
export default ContaCorrenteGrid;