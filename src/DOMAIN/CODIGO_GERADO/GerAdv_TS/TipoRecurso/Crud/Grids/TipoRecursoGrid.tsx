//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TipoRecursoEmpty } from "../../../Models/TipoRecurso";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import TipoRecursoInc from "../Inc/TipoRecurso";
import { ITipoRecurso } from "../../Interfaces/interface.TipoRecurso";
import { TipoRecursoService } from "../../Services/TipoRecurso.service";
import { TipoRecursoApi } from "../../Apis/ApiTipoRecurso";
import { TipoRecursoGridMobileComponent } from "../GridsMobile/TipoRecurso";
import { TipoRecursoGridDesktopComponent } from "../GridsDesktop/TipoRecurso";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTipoRecurso } from "../../Filters/TipoRecurso";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import TipoRecursoWindow from "./TipoRecursoWindow";

const TipoRecursoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tiporecurso, setTipoRecurso] = useState<ITipoRecurso[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTipoRecurso, setSelectedTipoRecurso] = useState<ITipoRecurso>(TipoRecursoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TipoRecursoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTipoRecurso | undefined | null>(null);

    const tiporecursoService = useMemo(() => {
      return new TipoRecursoService(
          new TipoRecursoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTipoRecurso = async (filtro?: FilterTipoRecurso | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tiporecursoService.getList(filtro ?? {} as FilterTipoRecurso);
        setTipoRecurso(data);
      }
      else {
        const data = await tiporecursoService.getAll(filtro ?? {} as FilterTipoRecurso);
        setTipoRecurso(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTipoRecurso(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tiporecurso: ITipoRecurso) => {
      if (isMobile) {
        router.push(`/pages/tiporecurso/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tiporecurso.id}`);
      } else {
        setSelectedTipoRecurso(tiporecurso);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tiporecurso/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTipoRecurso(TipoRecursoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTipoRecurso(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tiporecurso = e.dataItem;		
        setDeleteId(tiporecurso.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTipoRecurso(currFilter);
            } catch {
            // falta uma mensagem de erro
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

    return (
      <>
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <TipoRecursoGridMobileComponent data={tiporecurso} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <TipoRecursoGridDesktopComponent data={tiporecurso} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <TipoRecursoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTipoRecurso={selectedTipoRecurso}>       
        </TipoRecursoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TipoRecursoGrid;