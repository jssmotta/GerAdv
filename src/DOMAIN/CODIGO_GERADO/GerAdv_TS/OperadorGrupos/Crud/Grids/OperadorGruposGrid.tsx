//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { OperadorGruposEmpty } from "../../../Models/OperadorGrupos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IOperadorGrupos } from "../../Interfaces/interface.OperadorGrupos";
import { OperadorGruposService } from "../../Services/OperadorGrupos.service";
import { OperadorGruposApi } from "../../Apis/ApiOperadorGrupos";
import { OperadorGruposGridMobileComponent } from "../GridsMobile/OperadorGrupos";
import { OperadorGruposGridDesktopComponent } from "../GridsDesktop/OperadorGrupos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterOperadorGrupos } from "../../Filters/OperadorGrupos";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import OperadorGruposWindow from "./OperadorGruposWindow";

const OperadorGruposGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [operadorgrupos, setOperadorGrupos] = useState<IOperadorGrupos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedOperadorGrupos, setSelectedOperadorGrupos] = useState<IOperadorGrupos>(OperadorGruposEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new OperadorGruposApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterOperadorGrupos | undefined | null>(null);

    const operadorgruposService = useMemo(() => {
      return new OperadorGruposService(
          new OperadorGruposApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchOperadorGrupos = async (filtro?: FilterOperadorGrupos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await operadorgruposService.getList(filtro ?? {} as FilterOperadorGrupos);
        setOperadorGrupos(data);
      }
      else {
        const data = await operadorgruposService.getAll(filtro ?? {} as FilterOperadorGrupos);
        setOperadorGrupos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchOperadorGrupos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (operadorgrupos: IOperadorGrupos) => {
      if (isMobile) {
        router.push(`/pages/operadorgrupos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${operadorgrupos.id}`);
      } else {
        setSelectedOperadorGrupos(operadorgrupos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/operadorgrupos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedOperadorGrupos(OperadorGruposEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchOperadorGrupos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const operadorgrupos = e.dataItem;		
        setDeleteId(operadorgrupos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchOperadorGrupos(currFilter);
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
           <OperadorGruposGridMobileComponent data={operadorgrupos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <OperadorGruposGridDesktopComponent data={operadorgrupos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <OperadorGruposWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedOperadorGrupos={selectedOperadorGrupos}>       
        </OperadorGruposWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default OperadorGruposGrid;