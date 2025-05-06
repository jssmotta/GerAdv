import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import DivisaoTribunalInc from "../Inc/DivisaoTribunal";
import { IDivisaoTribunal } from "../../Interfaces/interface.DivisaoTribunal";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { DivisaoTribunalEmpty } from "@/app/GerAdv_TS/Models/DivisaoTribunal";
import { useWindow } from "@/app/hooks/useWindows";

interface DivisaoTribunalWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedDivisaoTribunal?: IDivisaoTribunal;
    onSuccess: () => void;
    onError: () => void;
}

const DivisaoTribunalWindow: React.FC<DivisaoTribunalWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedDivisaoTribunal,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/divisaotribunal/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedDivisaoTribunal?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedDivisaoTribunal]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={702}
                    newWidth={1440}
                    id={(selectedDivisaoTribunal?.id ?? 0).toString()}
                >
                    <DivisaoTribunalInc
                        id={selectedDivisaoTribunal?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowDivisaoTribunal: React.FC<DivisaoTribunalWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <DivisaoTribunalWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedDivisaoTribunal={DivisaoTribunalEmpty()}>
        </DivisaoTribunalWindow>
    )
};

export default DivisaoTribunalWindow;