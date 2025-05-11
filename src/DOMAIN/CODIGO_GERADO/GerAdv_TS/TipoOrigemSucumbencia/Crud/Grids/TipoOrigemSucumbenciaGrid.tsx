//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TipoOrigemSucumbenciaEmpty } from "../../../Models/TipoOrigemSucumbencia";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { ITipoOrigemSucumbencia } from "../../Interfaces/interface.TipoOrigemSucumbencia";
import { TipoOrigemSucumbenciaService } from "../../Services/TipoOrigemSucumbencia.service";
import { TipoOrigemSucumbenciaApi } from "../../Apis/ApiTipoOrigemSucumbencia";
import { TipoOrigemSucumbenciaGridMobileComponent } from "../GridsMobile/TipoOrigemSucumbencia";
import { TipoOrigemSucumbenciaGridDesktopComponent } from "../GridsDesktop/TipoOrigemSucumbencia";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTipoOrigemSucumbencia } from "../../Filters/TipoOrigemSucumbencia";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import TipoOrigemSucumbenciaWindow from "./TipoOrigemSucumbenciaWindow";

const TipoOrigemSucumbenciaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tipoorigemsucumbencia, setTipoOrigemSucumbencia] = useState<ITipoOrigemSucumbencia[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTipoOrigemSucumbencia, setSelectedTipoOrigemSucumbencia] = useState<ITipoOrigemSucumbencia>(TipoOrigemSucumbenciaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TipoOrigemSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTipoOrigemSucumbencia | undefined | null>(null);

    const tipoorigemsucumbenciaService = useMemo(() => {
      return new TipoOrigemSucumbenciaService(
          new TipoOrigemSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTipoOrigemSucumbencia = async (filtro?: FilterTipoOrigemSucumbencia | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tipoorigemsucumbenciaService.getList(filtro ?? {} as FilterTipoOrigemSucumbencia);
        setTipoOrigemSucumbencia(data);
      }
      else {
        const data = await tipoorigemsucumbenciaService.getAll(filtro ?? {} as FilterTipoOrigemSucumbencia);
        setTipoOrigemSucumbencia(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTipoOrigemSucumbencia(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tipoorigemsucumbencia: ITipoOrigemSucumbencia) => {
      if (isMobile) {
        router.push(`/pages/tipoorigemsucumbencia/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tipoorigemsucumbencia.id}`);
      } else {
        setSelectedTipoOrigemSucumbencia(tipoorigemsucumbencia);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tipoorigemsucumbencia/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTipoOrigemSucumbencia(TipoOrigemSucumbenciaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTipoOrigemSucumbencia(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tipoorigemsucumbencia = e.dataItem;		
        setDeleteId(tipoorigemsucumbencia.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTipoOrigemSucumbencia(currFilter);
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
           <TipoOrigemSucumbenciaGridMobileComponent data={tipoorigemsucumbencia} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <TipoOrigemSucumbenciaGridDesktopComponent data={tipoorigemsucumbencia} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <TipoOrigemSucumbenciaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTipoOrigemSucumbencia={selectedTipoOrigemSucumbencia}>       
        </TipoOrigemSucumbenciaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TipoOrigemSucumbenciaGrid;