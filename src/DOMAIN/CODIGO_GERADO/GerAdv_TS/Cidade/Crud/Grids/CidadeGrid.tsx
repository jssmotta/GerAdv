//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { CidadeEmpty } from '../../../Models/Cidade';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ICidade } from '../../Interfaces/interface.Cidade';
import { CidadeService } from '../../Services/Cidade.service';
import { CidadeApi } from '../../Apis/ApiCidade';
import { CidadeGridMobileComponent } from '../GridsMobile/Cidade';
import { CidadeGridDesktopComponent } from '../GridsDesktop/Cidade';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterCidade } from '../../Filters/Cidade';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import CidadeWindow from './CidadeWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useCidadeList } from '../../Hooks/hookCidade';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const CidadeGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const cidadeService = useMemo(() => {
    return new CidadeService(
    new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: cidade, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useCidadeList(cidadeService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedCidade, setSelectedCidade] = useState<ICidade>(CidadeEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterCidade | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterCidade | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterCidade);
};
// Handlers para o grid
const handleRowClick = (cidade: ICidade) => {
  setSelectedCidade(cidade);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedCidade(CidadeEmpty());
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
  const cidade = e.dataItem;
  setDeleteId(cidade.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await cidadeService.deleteCidade(deleteId);
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
    <CidadeGridMobileComponent
    data={cidade}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <CidadeGridDesktopComponent
    data={cidade}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <CidadeWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedCidade={selectedCidade}
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
export default CidadeGrid;