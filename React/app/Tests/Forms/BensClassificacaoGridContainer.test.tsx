// BensClassificacaoGridContainer.test.tsx
import React from 'react';
import { render, screen } from '@testing-library/react';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import BensClassificacaoGridContainer from '@/app/GerAdv_TS/BensClassificacao/Components/BensClassificacaoGridContainer';
describe('BensClassificacaoGridContainer', () => {
  it('renders the grid component output', () => {
    // Mock grid with a render method
    const mockGrid: IGridComponent = {
      render: () => <div data-testid='mock-grid'>Mock Grid Content</div>
    };
    render(<BensClassificacaoGridContainer grid={mockGrid} />);
    // Assert the mock grid content is rendered
    expect(screen.getByTestId('mock-grid')).toHaveTextContent('Mock Grid Content');
  });
});