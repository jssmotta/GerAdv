'use client';
import { Button } from '@progress/kendo-react-buttons';
import { SvgIcon } from '@progress/kendo-react-common';
import { GridToolbar } from '@progress/kendo-react-grid';
import { plusIcon, filterIcon } from '@progress/kendo-svg-icons';
import ButtonVoiceFilter from '@/app/components/msi/ButtonVoiceFilter';
import { ICommandSpeakerRequest } from '@/app/models/ICommandSpeakerRequest';

interface GridToolbarProps {
  onAdd: () => void;
  onSearch?: () => void;
  onClearFilter?: () => void;
  hasActiveFilter?: boolean;
  onVoiceFilter?: (voiceCommand: ICommandSpeakerRequest) => void;
}  
export const AppGridToolbar: React.FC<GridToolbarProps> = ({ onAdd, onSearch, onClearFilter, hasActiveFilter, onVoiceFilter }) => (  
  <GridToolbar>
    <div>
      <Button
        title="Adicionar novo registro"
        className="k-button k-primary"
        onClick={onAdd}
        aria-label="Adicionar novo registro"
      >
        <SvgIcon icon={plusIcon} />
      </Button>&nbsp;&nbsp;
      {onSearch && (<>
      <Button
        title="Faça filtros ou busque registros"
        className={hasActiveFilter ? 'k-button k-current-filter-active' : 'k-button'}
        aria-label="Buscar/Filtrar/Pesquisar"
        onClick={onSearch}
      >
        <SvgIcon icon={filterIcon} />
      </Button>&nbsp;&nbsp;
      </>)}
      {onVoiceFilter && (
        <ButtonVoiceFilter 
          onVoiceFilter={onVoiceFilter}
          title="Filtrar Clientes por Comando de Voz"
        />
      )}
    </div>
  </GridToolbar>
);
