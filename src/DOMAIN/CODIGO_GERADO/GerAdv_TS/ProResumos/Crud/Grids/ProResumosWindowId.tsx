// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IProResumos } from "../../Interfaces/interface.ProResumos";
import { ProResumosService } from "../../Services/ProResumos.service";
import { ProResumosApi } from "../../Apis/ApiProResumos";
import ProResumosWindow from "./ProResumosWindow";

interface ProResumosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ProResumosWindowId: React.FC<ProResumosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const proresumosService = useMemo(() => {
        return new ProResumosService(
            new ProResumosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IProResumos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await proresumosService.fetchProResumosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ProResumosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedProResumos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ProResumosWindowId;