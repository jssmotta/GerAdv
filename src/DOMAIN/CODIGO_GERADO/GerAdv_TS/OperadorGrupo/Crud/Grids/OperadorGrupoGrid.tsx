//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { OperadorGrupoEmpty } from "../../../Models/OperadorGrupo";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import OperadorGrupoInc from "../Inc/OperadorGrupo";
import { IOperadorGrupo } from "../../Interfaces/interface.OperadorGrupo";
import { OperadorGrupoService } from "../../Services/OperadorGrupo.service";
import { OperadorGrupoApi } from "../../Apis/ApiOperadorGrupo";
import { OperadorGrupoGridMobileComponent } from "../GridsMobile/OperadorGrupo";
import { OperadorGrupoGridDesktopComponent } from "../GridsDesktop/OperadorGrupo";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterOperadorGrupo } from "../../Filters/OperadorGrupo";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import OperadorGrupoWindow from "./OperadorGrupoWindow";

const OperadorGrupoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [operadorgrupo, setOperadorGrupo] = useState<IOperadorGrupo[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedOperadorGrupo, setSelectedOperadorGrupo] = useState<IOperadorGrupo>(OperadorGrupoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new OperadorGrupoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterOperadorGrupo | undefined | null>(null);

    const operadorgrupoService = useMemo(() => {
      return new OperadorGrupoService(
          new OperadorGrupoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchOperadorGrupo = async (filtro?: FilterOperadorGrupo | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await operadorgrupoService.getAll(filtro ?? {} as FilterOperadorGrupo);
        setOperadorGrupo(data);
      }
      else {
        const data = await operadorgrupoService.getAll(filtro ?? {} as FilterOperadorGrupo);
        setOperadorGrupo(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchOperadorGrupo(currFilter);
    }, [showInc]);
  
    const handleRowClick = (operadorgrupo: IOperadorGrupo) => {
      if (isMobile) {
        router.push(`/pages/operadorgrupo/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${operadorgrupo.id}`);
      } else {
        setSelectedOperadorGrupo(operadorgrupo);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/operadorgrupo/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedOperadorGrupo(OperadorGrupoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchOperadorGrupo(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const operadorgrupo = e.dataItem;		
        setDeleteId(operadorgrupo.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchOperadorGrupo(currFilter);
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
            
        {isMobile ?
           <OperadorGrupoGridMobileComponent data={operadorgrupo} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <OperadorGrupoGridDesktopComponent data={operadorgrupo} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <OperadorGrupoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedOperadorGrupo={selectedOperadorGrupo}>       
        </OperadorGrupoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default OperadorGrupoGrid;