// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ITribEnderecos } from "../../Interfaces/interface.TribEnderecos";
import { TribEnderecosService } from "../../Services/TribEnderecos.service";
import { TribEnderecosApi } from "../../Apis/ApiTribEnderecos";
import TribEnderecosWindow from "./TribEnderecosWindow";

interface TribEnderecosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const TribEnderecosWindowId: React.FC<TribEnderecosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const tribenderecosService = useMemo(() => {
        return new TribEnderecosService(
            new TribEnderecosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ITribEnderecos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await tribenderecosService.fetchTribEnderecosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <TribEnderecosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedTribEnderecos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default TribEnderecosWindowId;