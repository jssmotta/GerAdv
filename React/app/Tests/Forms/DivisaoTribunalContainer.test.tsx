import React from 'react';
import { render } from '@testing-library/react';
import DivisaoTribunalIncContainer from '@/app/GerAdv_TS/DivisaoTribunal/Components/DivisaoTribunalIncContainer';
// DivisaoTribunalIncContainer.test.tsx
// Mock do DivisaoTribunalInc
jest.mock('@/app/GerAdv_TS/DivisaoTribunal/Crud/Inc/DivisaoTribunal', () => (props: any) => (
<div data-testid='divisaotribunal-inc-mock' {...props} />
));
describe('DivisaoTribunalIncContainer', () => {
  it('deve renderizar DivisaoTribunalInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <DivisaoTribunalIncContainer id={id} navigator={mockNavigator} />
  );
  const divisaotribunalInc = getByTestId('divisaotribunal-inc-mock');
  expect(divisaotribunalInc).toBeInTheDocument();
  expect(divisaotribunalInc.getAttribute('id')).toBe(id.toString());

});
});