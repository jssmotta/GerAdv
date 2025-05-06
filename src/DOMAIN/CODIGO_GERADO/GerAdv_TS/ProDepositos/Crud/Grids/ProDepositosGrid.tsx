//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProDepositosEmpty } from "../../../Models/ProDepositos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IProDepositos } from "../../Interfaces/interface.ProDepositos";
import { ProDepositosService } from "../../Services/ProDepositos.service";
import { ProDepositosApi } from "../../Apis/ApiProDepositos";
import { ProDepositosGridMobileComponent } from "../GridsMobile/ProDepositos";
import { ProDepositosGridDesktopComponent } from "../GridsDesktop/ProDepositos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProDepositos } from "../../Filters/ProDepositos";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ProDepositosWindow from "./ProDepositosWindow";

const ProDepositosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [prodepositos, setProDepositos] = useState<IProDepositos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProDepositos, setSelectedProDepositos] = useState<IProDepositos>(ProDepositosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProDepositosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProDepositos | undefined | null>(null);

    const prodepositosService = useMemo(() => {
      return new ProDepositosService(
          new ProDepositosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProDepositos = async (filtro?: FilterProDepositos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await prodepositosService.getAll(filtro ?? {} as FilterProDepositos);
        setProDepositos(data);
      }
      else {
        const data = await prodepositosService.getAll(filtro ?? {} as FilterProDepositos);
        setProDepositos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProDepositos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (prodepositos: IProDepositos) => {
      if (isMobile) {
        router.push(`/pages/prodepositos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${prodepositos.id}`);
      } else {
        setSelectedProDepositos(prodepositos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/prodepositos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProDepositos(ProDepositosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProDepositos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const prodepositos = e.dataItem;		
        setDeleteId(prodepositos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProDepositos(currFilter);
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
           <ProDepositosGridMobileComponent data={prodepositos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ProDepositosGridDesktopComponent data={prodepositos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ProDepositosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProDepositos={selectedProDepositos}>       
        </ProDepositosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProDepositosGrid;