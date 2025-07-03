//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { ProTipoBaixaEmpty } from '../../../Models/ProTipoBaixa';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IProTipoBaixa } from '../../Interfaces/interface.ProTipoBaixa';
import { ProTipoBaixaService } from '../../Services/ProTipoBaixa.service';
import { ProTipoBaixaApi } from '../../Apis/ApiProTipoBaixa';
import { ProTipoBaixaGridMobileComponent } from '../GridsMobile/ProTipoBaixa';
import { ProTipoBaixaGridDesktopComponent } from '../GridsDesktop/ProTipoBaixa';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterProTipoBaixa } from '../../Filters/ProTipoBaixa';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import ProTipoBaixaWindow from './ProTipoBaixaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useProTipoBaixaList } from '../../Hooks/hookProTipoBaixa';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const ProTipoBaixaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const protipobaixaService = useMemo(() => {
    return new ProTipoBaixaService(
    new ProTipoBaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: protipobaixa, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useProTipoBaixaList(protipobaixaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedProTipoBaixa, setSelectedProTipoBaixa] = useState<IProTipoBaixa>(ProTipoBaixaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterProTipoBaixa | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterProTipoBaixa | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterProTipoBaixa);
};
// Handlers para o grid
const handleRowClick = (protipobaixa: IProTipoBaixa) => {
  setSelectedProTipoBaixa(protipobaixa);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedProTipoBaixa(ProTipoBaixaEmpty());
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
  const protipobaixa = e.dataItem;
  setDeleteId(protipobaixa.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await protipobaixaService.deleteProTipoBaixa(deleteId);
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
    <ProTipoBaixaGridMobileComponent
    data={protipobaixa}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <ProTipoBaixaGridDesktopComponent
    data={protipobaixa}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <ProTipoBaixaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedProTipoBaixa={selectedProTipoBaixa}
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
export default ProTipoBaixaGrid;