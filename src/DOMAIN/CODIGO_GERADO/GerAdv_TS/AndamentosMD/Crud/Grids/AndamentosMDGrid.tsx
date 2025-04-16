//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AndamentosMDEmpty } from "../../../Models/AndamentosMD";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AndamentosMDInc from "../Inc/AndamentosMD";
import { IAndamentosMD } from "../../Interfaces/interface.AndamentosMD";
import { AndamentosMDService } from "../../Services/AndamentosMD.service";
import { AndamentosMDApi } from "../../Apis/ApiAndamentosMD";
import { AndamentosMDGridMobileComponent } from "../GridsMobile/AndamentosMD";
import { AndamentosMDGridDesktopComponent } from "../GridsDesktop/AndamentosMD";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAndamentosMD } from "../../Filters/AndamentosMD";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AndamentosMDWindow from "./AndamentosMDWindow";

const AndamentosMDGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [andamentosmd, setAndamentosMD] = useState<IAndamentosMD[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAndamentosMD, setSelectedAndamentosMD] = useState<IAndamentosMD>(AndamentosMDEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AndamentosMDApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAndamentosMD | undefined | null>(null);

    const andamentosmdService = useMemo(() => {
      return new AndamentosMDService(
          new AndamentosMDApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAndamentosMD = async (filtro?: FilterAndamentosMD | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await andamentosmdService.getList(filtro ?? {} as FilterAndamentosMD);
        setAndamentosMD(data);
      }
      else {
        const data = await andamentosmdService.getAll(filtro ?? {} as FilterAndamentosMD);
        setAndamentosMD(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAndamentosMD(currFilter);
    }, [showInc]);
  
    const handleRowClick = (andamentosmd: IAndamentosMD) => {
      if (isMobile) {
        router.push(`/pages/andamentosmd/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${andamentosmd.id}`);
      } else {
        setSelectedAndamentosMD(andamentosmd);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/andamentosmd/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAndamentosMD(AndamentosMDEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAndamentosMD(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const andamentosmd = e.dataItem;		
        setDeleteId(andamentosmd.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAndamentosMD(currFilter);
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
           <AndamentosMDGridMobileComponent data={andamentosmd} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AndamentosMDGridDesktopComponent data={andamentosmd} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AndamentosMDWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAndamentosMD={selectedAndamentosMD}>       
        </AndamentosMDWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AndamentosMDGrid;