//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { LivroCaixaEmpty } from '../../../Models/LivroCaixa';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ILivroCaixa } from '../../Interfaces/interface.LivroCaixa';
import { LivroCaixaService } from '../../Services/LivroCaixa.service';
import { LivroCaixaApi } from '../../Apis/ApiLivroCaixa';
import { LivroCaixaGridMobileComponent } from '../GridsMobile/LivroCaixa';
import { LivroCaixaGridDesktopComponent } from '../GridsDesktop/LivroCaixa';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterLivroCaixa } from '../../Filters/LivroCaixa';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import LivroCaixaWindow from './LivroCaixaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useLivroCaixaList } from '../../Hooks/hookLivroCaixa';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const LivroCaixaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const livrocaixaService = useMemo(() => {
    return new LivroCaixaService(
    new LivroCaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: livrocaixa, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useLivroCaixaList(livrocaixaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedLivroCaixa, setSelectedLivroCaixa] = useState<ILivroCaixa>(LivroCaixaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterLivroCaixa | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterLivroCaixa | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterLivroCaixa);
};
// Handlers para o grid
const handleRowClick = (livrocaixa: ILivroCaixa) => {
  setSelectedLivroCaixa(livrocaixa);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedLivroCaixa(LivroCaixaEmpty());
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
  const livrocaixa = e.dataItem;
  setDeleteId(livrocaixa.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await livrocaixaService.deleteLivroCaixa(deleteId);
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
    <LivroCaixaGridMobileComponent
    data={livrocaixa}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <LivroCaixaGridDesktopComponent
    data={livrocaixa}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <LivroCaixaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedLivroCaixa={selectedLivroCaixa}
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
export default LivroCaixaGrid;