//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { RegimeTributacaoEmpty } from '../../../Models/RegimeTributacao';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IRegimeTributacao } from '../../Interfaces/interface.RegimeTributacao';
import { RegimeTributacaoService } from '../../Services/RegimeTributacao.service';
import { RegimeTributacaoApi } from '../../Apis/ApiRegimeTributacao';
import { RegimeTributacaoGridMobileComponent } from '../GridsMobile/RegimeTributacao';
import { RegimeTributacaoGridDesktopComponent } from '../GridsDesktop/RegimeTributacao';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterRegimeTributacao } from '../../Filters/RegimeTributacao';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import RegimeTributacaoWindow from './RegimeTributacaoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useRegimeTributacaoList } from '../../Hooks/hookRegimeTributacao';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const RegimeTributacaoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const regimetributacaoService = useMemo(() => {
    return new RegimeTributacaoService(
    new RegimeTributacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: regimetributacao, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useRegimeTributacaoList(regimetributacaoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedRegimeTributacao, setSelectedRegimeTributacao] = useState<IRegimeTributacao>(RegimeTributacaoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterRegimeTributacao | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterRegimeTributacao | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterRegimeTributacao);
};
// Handlers para o grid
const handleRowClick = (regimetributacao: IRegimeTributacao) => {
  setSelectedRegimeTributacao(regimetributacao);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedRegimeTributacao(RegimeTributacaoEmpty());
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
  const regimetributacao = e.dataItem;
  setDeleteId(regimetributacao.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await regimetributacaoService.deleteRegimeTributacao(deleteId);
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
    <RegimeTributacaoGridMobileComponent
    data={regimetributacao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <RegimeTributacaoGridDesktopComponent
    data={regimetributacao}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <RegimeTributacaoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedRegimeTributacao={selectedRegimeTributacao}
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
export default RegimeTributacaoGrid;