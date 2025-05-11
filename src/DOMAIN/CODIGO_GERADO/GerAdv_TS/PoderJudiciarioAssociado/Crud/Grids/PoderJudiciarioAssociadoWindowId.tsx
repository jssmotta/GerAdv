// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IPoderJudiciarioAssociado } from "../../Interfaces/interface.PoderJudiciarioAssociado";
import { PoderJudiciarioAssociadoService } from "../../Services/PoderJudiciarioAssociado.service";
import { PoderJudiciarioAssociadoApi } from "../../Apis/ApiPoderJudiciarioAssociado";
import PoderJudiciarioAssociadoWindow from "./PoderJudiciarioAssociadoWindow";

interface PoderJudiciarioAssociadoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const PoderJudiciarioAssociadoWindowId: React.FC<PoderJudiciarioAssociadoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const poderjudiciarioassociadoService = useMemo(() => {
        return new PoderJudiciarioAssociadoService(
            new PoderJudiciarioAssociadoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IPoderJudiciarioAssociado | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await poderjudiciarioassociadoService.fetchPoderJudiciarioAssociadoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <PoderJudiciarioAssociadoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedPoderJudiciarioAssociado={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default PoderJudiciarioAssociadoWindowId;